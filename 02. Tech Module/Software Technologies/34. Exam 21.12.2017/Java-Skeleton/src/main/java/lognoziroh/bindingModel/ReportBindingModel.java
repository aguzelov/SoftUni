package lognoziroh.bindingModel;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

public class ReportBindingModel {
    @NotNull
    @Size(min=1)
    private String status;

    @NotNull
    @Size(min=1)
    private String message;

    @NotNull
    @Size(min=1)
    private String origin;

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public String getOrigin() {
        return origin;
    }

    public void setOrigin(String origin) {
        this.origin = origin;
    }
}

/*
•	id – technology-dependent identifier (ObjectID for JavaScript, int for all other technologies)
•	status – non-empty text (will either be “Normal”, “Warning” or “Critical”).
•	message – non-empty text
•	origin – non-empty text

 */
