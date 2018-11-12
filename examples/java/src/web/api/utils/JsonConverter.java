package web.api.utils;

import java.io.InputStream;
import java.net.URL;
import java.util.Date;
import java.util.Properties;

import org.codehaus.jackson.map.ObjectMapper;
import org.codehaus.jackson.map.DeserializationConfig.Feature;

import web.api.model.ApiResponse;

public class JsonConverter {

	public ApiResponse getApiJson(String cnId, Date startDate, Date endDate) throws Exception {

		//get the API url from the config.properties
		InputStream objFileInputStream = getClass().getClassLoader().getResourceAsStream("config.properties");
		Properties commonProperties = new Properties();
		commonProperties.load(objFileInputStream);
		String findByIdUrl = String.valueOf(commonProperties.get("FindByIdUrl"));
		
		URL url = new URL(findByIdUrl + cnId);
		
		//parse JSON results with Jackson
		ObjectMapper mapper = new ObjectMapper();
		mapper.configure(Feature.FAIL_ON_UNKNOWN_PROPERTIES, false);
		ApiResponse response = mapper.readValue(url, ApiResponse.class);
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
