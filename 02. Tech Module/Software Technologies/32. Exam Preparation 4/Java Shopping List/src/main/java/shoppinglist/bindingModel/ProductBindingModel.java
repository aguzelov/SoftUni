package shoppinglist.bindingModel;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

public class ProductBindingModel {
    @NotNull
    private Integer id;

	@NotNull
    @Size(min=1)
    private String name;

	@NotNull
    private Integer priority;

    @NotNull
    @Size(min=1)
    private String status;

    @NotNull
    private Integer quantity;

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

    public Integer getPriority() {
        return priority;
    }

    public void setPriority(Integer priority) {
        this.priority = priority;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public Integer getQuantity() {
        return quantity;
    }

    public void setQuantity(Integer quantity) {
        this.quantity = quantity;
    }
}
