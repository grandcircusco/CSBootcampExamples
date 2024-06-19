package co.grandcircus.avengersapi.model;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;

@Entity
// The @Table annotation is optional.
// Here we prefix the table name in case you already have a movie table in your database.
@Table(name = "avengers_movie")
public class Movie {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;
	private String title;
	private Integer releaseYear;

	public Movie() {
		super();
	}

	public Movie(String title, Integer releaseYear) {
		super();
		this.title = title;
		this.releaseYear = releaseYear;
	}

	public Movie(Long id, String title, Integer releaseYear) {
		super();
		this.id = id;
		this.title = title;
		this.releaseYear = releaseYear;
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public Integer getReleaseYear() {
		return releaseYear;
	}

	public void setReleaseYear(Integer releaseYear) {
		this.releaseYear = releaseYear;
	}

}
