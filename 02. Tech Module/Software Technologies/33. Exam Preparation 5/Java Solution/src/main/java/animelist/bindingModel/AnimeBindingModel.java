package animelist.bindingModel;

public class AnimeBindingModel {

    private Integer id;

    private Integer rating;

    private  String name;

    private String description;

    private String watched;

    public AnimeBindingModel() {
    }

    public AnimeBindingModel(Integer id, Integer rating, String name, String description, String watched) {
        this.id = id;
        this.rating = rating;
        this.name = name;
        this.description = description;
        this.watched = watched;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getRating() {
        return rating;
    }

    public void setRating(Integer rating) {
        this.rating = rating;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getWatched() {
        return watched;
    }

    public void setWatched(String watched) {
        this.watched = watched;
    }
}
