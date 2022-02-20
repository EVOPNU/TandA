package suraifokkusu.entities;

import javax.persistence.*;

@Entity
public class Product {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false)
    private String titleOfImage;

    @Column(nullable = false)
    private String urlOfImage;

    public Product(){
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getTitleOfImage() {
        return titleOfImage;
    }

    public void setTitleOfImage(String titleOfImage) {
        this.titleOfImage = titleOfImage;
    }

    public String getUrlOfImage() {
        return urlOfImage;
    }

    public void setUrlOfImage(String urlOfImage) {
        this.urlOfImage = urlOfImage;
    }

    @Override
    public String toString() {
        return "Product{" +
                "id=" + id +
                ", TitleOfImage='" + titleOfImage + '\'' +
                ", UrlOfImage='" + urlOfImage + '\'' +
                '}';
    }
}