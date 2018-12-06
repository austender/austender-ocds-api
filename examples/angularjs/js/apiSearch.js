var app = angular.module('webApp', []);

app.filter('date', function($filter)
{
    return function(input)
    {
        if(input == null){ return ""; }
        var _date = $filter('date')(new Date(input), 'dd/MM/yyyy');
        return _date.toUpperCase();
    };
});

app.controller('searchForm', function($scope, $http) {
	$scope.searchById = function(cnId){
		if(!cnId){cnId = $scope.cnId;}else{$scope.cnId=cnId;}
		
		if(!cnId){
			$scope.errorMessage = "You must enter CN ID."
			$scope.showResults = false;
		}
		else{
			$scope.search(findByIdUrl + cnId);
			$scope.cnId = cnId;
		}
	}

	$scope.searchByPublishDate = function(){
		if(!$scope.dateStart || !$scope.dateEnd){
			$scope.errorMessage = "You must enter Publish Date."
			$scope.showResults = false;
		}
		else{
			 var startDate = $scope.formatDate($scope.dateStart);
			 var endDate = $scope.formatDate($scope.dateEnd, true);
			 console.log(startDate + "/" + endDate);
			$scope.search(findByPublishDateUrl + startDate + "/" + endDate);
		}
		
	}
	$scope.search = function(url) {
		$scope.showResults = false;
		$scope.errorMessage = ""
		$scope.loading = true;
		$http({
			method: 'GET',
			url: url
		}).then(function successCallback(response) {
			$scope.showResults = true;
			if(url.includes("findById")){
				if(response.data.releases.length >= 1){
					var firstRelease = response.data.releases[0];
					firstRelease.isParent = firstRelease.tag[0] == "contract";
					if(firstRelease.isParent && response.data.releases.length > 1){
						firstRelease.contracts[0].amendments = [];
						for (var i=1; i<response.data.releases.length; i++) {
						    var release = response.data.releases[i];
						    console.log(release.contracts[0].amendments.length);
						    if(release.contracts[0].amendments.length > 0){
						    	var amendment = {
						    		id : release.contracts[0].amendments[0].id,
						    		date : release.date
						    	}; 

						    	firstRelease.contracts[0].amendments.push(amendment);
						    }
						}
					}
					response.data.releases = [];
					response.data.releases.push(firstRelease);
				}
			}
			else{
				var results = [];
				var amendments = [];
				response.data.releases.forEach(function(release){
	            	if(release.tag[0] == "contractAmendment"){
	            		var amendment = {
	            			id : release.contracts[0].amendments[0].id,
	            			date : release.date
	            		};
	            		amendments.push(amendment);
	            	}
	        	});

				response.data.releases.forEach(function(release){
					if(release.tag[0] == "contractAmendment"){
						results.push(release);
					}
					else{
						release.isParent = true;
						release.contracts[0].amendments = amendments.filter(function(amendment) {
						  return amendment.id.includes(release.contracts[0].id + "-A");
						});
						results.push(release);
					}
				});

			}


			$scope.data = response.data;

		}, function errorCallback(response) {
			$scope.showResults = true;
			$scope.data = response.data;
		}).finally(function() {
			$scope.loading = false;
		});
	};

	$scope.formatDate = function(strDate,isEndDate){
		var date = new Date(strDate);
		var day = date.getDate();
		if(isEndDate){
			day += 1;
		}
		return date.getFullYear()+"-"+(date.getMonth()+1)+"-"+day+"T00:00:00Z";
	}
});

app.filter("trustHtmlContent", ['$sce', $sce => htmlCode => $sce.trustAsHtml(htmlCode)]);




