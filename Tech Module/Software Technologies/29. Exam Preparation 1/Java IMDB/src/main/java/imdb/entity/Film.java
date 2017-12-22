package imdb.entity;

import javax.persistence.*;

@Entity
@Table(name = "films")
public class Film {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	public Integer id;

    @Column(nullable = false)
	public String name;

    @Column(nullable = false)
	public String genre;

    @Column(nullable = false)
	public String director;

    @Column(nullable = false)
	public Integer year;

    public Film(Integer id, String name, String genre, String director, Integer year) {
        this.id = id;
        this.name = name;
        this.genre = genre;
        this.director = director;
        this.year = year;
    }

    public Film() {

    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getGenre() {
        return genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }

    public String getDirector() {
        return director;
    }

    public void setDirector(String director) {
        this.director = director;
    }

    public Integer getYear() {
        return year;
    }

    public void setYear(Integer year) {
        this.year = year;
    }
}
