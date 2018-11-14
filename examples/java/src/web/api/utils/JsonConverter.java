package web.api.utils;

import java.io.InputStream;
import java.net.URL;
import java.util.Properties;

import org.codehaus.jackson.map.ObjectMapper;
import org.codehaus.jackson.map.DeserializationConfig.Feature;

import web.api.model.ApiResponse;
public class JsonConverter {

	public ApiResponse getApiJson(String cnId, String startDate, String endDate) throws Exception {
		ApiResponse response = new ApiResponse();
		//get the API url from the config.properties
		InputStream objFileInputStream = getClass().getClassLoader().getResourceAsStream("config.properties");
		Properties commonProperties = new Properties();
		commonProperties.load(objFileInputStream);
		
		ObjectMapper mapper = new ObjectMapper();
		mapper.configure(Feature.FAIL_ON_UNKNOWN_PROPERTIES, false);
		String url = "";
		
		if(cnId != null && cnId.length() > 0) {
			url = String.valueOf(commonProperties.get("FindByIdUrl")) + cnId;
		}else {
			url = String.valueOf(commonProperties.get("FindByPublishDateUrl")) + startDate + "/" + endDate;
		}
		
		URL apiUrl = new URL(url);
		//parse JSON results with Jackson
		response = mapper.readValue(apiUrl, ApiResponse.class);

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
}
