package web.api.model;

import java.util.List;

public class Release {
	public String language;
	public String date;
    public String ocid;
    public String id;
    public String initiationType;
    public List<Party> parties;
    public List<Contract> contracts;
    
    public List<Contract> getContracts() {
		return contracts;
	}
	public void setContracts(List<Contract> contracts) {
		this.contracts = contracts;
	}
	public List<Party> getParties() {
		return parties;
	}
	public void setParties(List<Party> parties) {
		this.parties = parties;
	}
	public String getLanguage() {
		return language;
	}
	public void setLanguage(String language) {
		this.language = language;
	}
	public String getDate() {
		return date;
	}
	public void setDate(String date) {
		this.date = date;
	}
	public String getOcid() {
		return ocid;
	}
	public void setOcid(String ocid) {
		this.ocid = ocid;
	}

	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getInitiationType() {
		return initiationType;
	}
	public void setInitiationType(String initiationType) {
		this.initiationType = initiationType;
	}
	
}
