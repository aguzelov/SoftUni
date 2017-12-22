package todolist.entity;

import javax.persistence.*;

@Entity
@Table(name = "tasks")
public class Task {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

	@Column(nullable = false)
    private String title;

    @Column(nullable = false)
    private String comments;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getComments() {
        return comments;
    }

    public void setComments(String comments) {
        this.comments = comments;
    }
}
