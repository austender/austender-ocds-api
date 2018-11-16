package web.api.model;

import java.util.List;

public class Item {
	public String id;
    public List<AdditionalClassification> additionalClassifications ;
    
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public List<AdditionalClassification> getAdditionalClassifications() {
		return additionalClassifications;
	}
	public void setAdditionalClassifications(List<AdditionalClassification> additionalClassifications) {
		this.additionalClassifications = additionalClassifications;
	}
    
    
}
