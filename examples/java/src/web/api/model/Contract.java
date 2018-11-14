package web.api.model;

import java.util.List;

public class Contract {
	public String id;
    public String type;
    public String awardId;

    public String dateSigned;

    public String description;

    public String status;
    
	public List<Amendment> amendments;

	public Value value;
	
	public Period period;
	
	
	public Period getPeriod() {
		return period;
	}

	public void setPeriod(Period period) {
		this.period = period;
	}

	public Value getValue() {
		return value;
	}

	public void setValue(Value value) {
		this.value = value;
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getAwardId() {
		return awardId;
	}

	public void setAwardId(String awardId) {
		this.awardId = awardId;
	}

	public String getDateSigned() {
		return dateSigned;
	}

	public void setDateSigned(String dateSigned) {
		this.dateSigned = dateSigned;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public List<Amendment> getAmendments() {
		return amendments;
	}

	public void setAmendments(List<Amendment> amendments) {
		this.amendments = amendments;
	}
	
	
}
