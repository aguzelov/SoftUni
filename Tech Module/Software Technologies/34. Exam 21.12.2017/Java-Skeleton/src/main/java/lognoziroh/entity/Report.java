package lognoziroh.entity;

import javax.persistence.*;

@Entity
@Table(name = "reports")
public class Report {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @Column(nullable = false)
    private String status;

    @Column(nullable = false)
    private String message;

    @Column(nullable = false)
    private String origin;

    public Report(String status, String message, String origin) {
        this.status = status;
        this.message = message;
        this.origin = origin;
    }

    public Report() {
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

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