package web.api.search;

import java.io.IOException;
import  javax.faces.bean.ManagedBean; 
import  javax.faces.bean.ViewScoped;
import org.codehaus.jackson.JsonParseException;
import org.codehaus.jackson.map.JsonMappingException;
import org.codehaus.jackson.map.ObjectMapper;
import web.api.model.ApiResponse;
import web.api.utils.JsonConverter;

@SuppressWarnings("deprecation")
@ManagedBean (name="apiSearch")  
@ViewScoped 
public class ApiSearch {
	private String cnId = "";
	private String startDate = "";
	private String endDate = "";
	private ApiResponse apiResponse;
	public ApiSearch() {
	}
	
	public void search() throws Exception {
		String url = "https://rrqcsg42vk.execute-api.ap-southeast-2.amazonaws.com/poc/ocds/findById/CN3512249";
	    String json = new JsonConverter().getApiJson(url);
		ObjectMapper mapper = new ObjectMapper();
		//mapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);

		try {
			this.apiResponse = mapper.readValue(json, ApiResponse.class);
		} catch (JsonParseException e) {
			e.printStackTrace();
		} catch (JsonMappingException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
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

