package web.api.model;

public class Amendment
{
    public String id ;
    public String date ;
    public String description ;
    public String rationale ;
    public String startdate ;
    public Double contractamendmentvalue ;
    public Double amendedvalue ;
    
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getDate() {
		return date;
	}
	public void setDate(String date) {
		this.date = date;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public String getRationale() {
		return rationale;
	}
	public void setRationale(String rationale) {
		this.rationale = rationale;
	}
	public String getStartdate() {
		return startdate;
	}
	public void setStartdate(String startdate) {
		this.startdate = startdate;
	}
	public Double getContractamendmentvalue() {
		return contractamendmentvalue;
	}
	public void setContractamendmentvalue(Double contractamendmentvalue) {
		this.contractamendmentvalue = contractamendmentvalue;
	}
	public Double getAmendedvalue() {
		return amendedvalue;
	}
	public void setAmendedvalue(Double amendedvalue) {
		this.amendedvalue = amendedvalue;
	}
    
    
}
