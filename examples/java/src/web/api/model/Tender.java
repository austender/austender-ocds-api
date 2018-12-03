package web.api.model;

public class Tender {
    public String id;
    public String procurementMethod;
    public String procurementMethodDetails;
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getProcurementMethod() {
		return procurementMethod;
	}
	public void setProcurementMethod(String procurementMethod) {
		this.procurementMethod = procurementMethod;
	}
	public String getProcurementMethodDetails() {
		return procurementMethodDetails;
	}
	public void setProcurementMethodDetails(String procurementMethodDetails) {
		this.procurementMethodDetails = procurementMethodDetails;
	}
	
    
    	
}
