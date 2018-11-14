package web.api.model;

import java.util.ArrayList;
import java.util.List;

public class ApiResponse {
	public String publishedDate;
	public List<Release> releases = new ArrayList<Release>();
	
    public List<Release> getReleases() {
		return releases;
	}

	public void setReleases(List<Release> releases) {
		this.releases = releases;
	}

	public String getPublishedDate() {
		return publishedDate;
	}

	public void setPublishedDate(String publishedDate) {
		this.publishedDate = publishedDate;
	}
}
