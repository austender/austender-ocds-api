package web.api.search;

import javax.faces.annotation.ManagedProperty;
import  javax.faces.bean.ManagedBean; 
import  javax.faces.bean.ViewScoped;

import web.api.model.ApiResponse;
import web.api.utils.JsonConverter;

@SuppressWarnings("deprecation")
@ManagedBean (name="apiSearch")  
@ViewScoped 
public class ApiSearch {
	@ManagedProperty(value = "#{param.cnId}")
	private String cnId = "";
	
	private String startDate;
	private String endDate;
	public boolean showResults = false;

	public boolean isShowResults() {
		return showResults;
	}

	public void setShowResults(boolean showResults) {
		this.showResults = showResults;
	}
	private ApiResponse apiResponse;
	public ApiSearch() {

	}
	
	public void search(){
		ApiResponse response = new ApiResponse();
		this.showResults = true;
		
		try {
			this.apiResponse = new JsonConverter().getApiJson(this.cnId, this.startDate, this.endDate);
		} catch (Exception e) {
			this.apiResponse = response;
		}
	}
		
	public String getCnId() {
		return cnId;
	}
	
	public void setCnId(String cnId) {
		this.cnId = cnId;
	}
	public String getStartDate() {
		return startDate;
	}
	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}
	public String getEndDate() {
		return endDate;
	}
	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}
	public ApiResponse getApiResponse() {
		return apiResponse;
	}
	public void setApiResponse(ApiResponse apiResponse) {
		this.apiResponse = apiResponse;
	}
}

