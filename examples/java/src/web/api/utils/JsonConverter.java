package web.api.utils;

import java.io.InputStream;
import java.net.URL;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Properties;
import java.util.stream.Collectors;

import org.codehaus.jackson.map.ObjectMapper;
import org.codehaus.jackson.map.DeserializationConfig.Feature;

import web.api.model.Amendment;
import web.api.model.Release;
import web.api.model.ApiResponse;
public class JsonConverter {

	public ApiResponse getApiJson(String cnId, String startDate, String endDate) throws Exception {
		ApiResponse response = new ApiResponse();
		//get the API url from the config.properties
		InputStream objFileInputStream = getClass().getClassLoader().getResourceAsStream("config.properties");
		Properties commonProperties = new Properties();
		commonProperties.load(objFileInputStream);
		startDate = formatDate(startDate, false);
		endDate = formatDate(endDate, true);
		
		ObjectMapper mapper = new ObjectMapper();
		mapper.configure(Feature.FAIL_ON_UNKNOWN_PROPERTIES, false);
		String url = "";
		Boolean findById = false;
		if(cnId != null && cnId.length() > 0) {
			url = String.valueOf(commonProperties.get("FindByIdUrl")) + cnId;
			findById = true;
		}else if(startDate.length() > 0 && startDate.length() > 0) {
			url = String.valueOf(commonProperties.get("FindByPublishDateUrl")) + startDate + "/" + endDate;
		}
		
		if(url != "") {
			URL apiUrl = new URL(url);
			//parse JSON results with Jackson
			response = mapper.readValue(apiUrl, ApiResponse.class);
			
			if(findById) {
				if(response.releases.size() >= 1) {
					Release firstRelease = response.releases.get(0);
					firstRelease.isParent = firstRelease.tag.get(0).equals("contract");
					
					if(firstRelease.isParent) {
						List<Amendment> amendments = new ArrayList<Amendment>();
						for(Release release: response.releases.subList( 1, response.releases.size())){
							if(!release.contracts.get(0).amendments.isEmpty() ) {
								Amendment amendment = new Amendment();
								amendment.id = release.contracts.get(0).amendments.get(0).id;
								amendment.date = release.date;
								amendments.add(amendment);
							}
						}
						
						if(!amendments.isEmpty()) {
							firstRelease.contracts.get(0).amendments = amendments;
						}	
					}
					
					response.releases = new ArrayList<Release>();
					response.releases.add(firstRelease);
				}
				else {
					return response;
				}
			}
			else {
				List<Release> results = new ArrayList<Release>();
				List<Amendment> amendments = new ArrayList<Amendment>();
				response.releases.stream().filter(r -> r.tag.contains("contractAmendment")).forEach((release) -> {
					Amendment amendment = new Amendment();                
					amendment.id = release.contracts.get(0).amendments.get(0).id;
					amendment.date = release.date;
					amendments.add(amendment);
                });
				
				for(Release release:response.releases) {
					if(release.tag.contains("contractAmendment")) {
						results.add(release);
					}
					else {
						release.isParent = true;
						release.contracts.get(0).amendments = amendments.stream().filter(a -> a.id.contains(release.contracts.get(0).id + "-A")).collect(Collectors.toList());;
						results.add(release);
					}
				}
			}
		}
		
		return response;
		
		/*URL obj = new URL(findByIdUrl + cnId);
		 HttpURLConnection con = (HttpURLConnection) obj.openConnection();
		// optional default is GET
		con.setRequestMethod("GET");
		// add request header
		con.setRequestProperty("User-Agent", "Mozilla/5.0");
		BufferedReader reader = new BufferedReader(new InputStreamReader(con.getInputStream()));
		String inputLine;
		StringBuffer response = new StringBuffer();
		while ((inputLine = reader.readLine()) != null) {
			response.append(inputLine);
		}
		reader.close();
		return response.toString();*/
	}
	
	public String formatDate(String date, Boolean isEndDate) throws ParseException {
		if(date != null && date.length()>0) {
			Date formatDate = new SimpleDateFormat("yyyy-MM-dd").parse(date);
			if(isEndDate) {
				Calendar c = Calendar.getInstance();
		        c.setTime(formatDate);
		        c.add(Calendar.DAY_OF_MONTH, 1);
		        formatDate = c.getTime();
			}
			
			return new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'").format(formatDate);
		}
		
		return "";
	}
}
