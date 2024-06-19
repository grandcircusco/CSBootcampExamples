package co.grandcircus.avengersapi.model;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;

@Entity
// The @Table annotation is optional.
// Here we prefix the table name to make it easy to find in your MySQL Workbench.
@Table(name = "avengers_character")
public class AvCharacter {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;
	
	private String name;
	private Integer strength;
	private Boolean good;
	private String skill;
	
	// -- Two types of relationships --
	// 1. A simple reference to the ID in the Movie entity
	private Long firstMovieId;
	// 2. JPA will automatically fetch from the World entity and it will be a
	// nested object in JSON
	@ManyToOne
	private World homeWorld;

	public AvCharacter() {
	}

	public AvCharacter(String name, Integer strength, Boolean good,
			String skill, Long firstMovieId, World homeWorld) {
		super();
		this.name = name;
		this.strength = strength;
		this.good = good;
		this.skill = skill;
		this.firstMovieId = firstMovieId;
		this.homeWorld = homeWorld;
	}

	public AvCharacter(Long id, String name, Integer strength, Boolean good,
			String skill, Long firstMovieId, World homeWorld) {
		super();
		this.id = id;
		this.name = name;
		this.strength = strength;
		this.good = good;
		this.skill = skill;
		this.firstMovieId = firstMovieId;
		this.homeWorld = homeWorld;
	}

	// Getters and Setters
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Integer getStrength() {
		return this.strength;
	}

	public void setStrength(Integer strength) {
		this.strength = strength;
	}

	public Boolean getGood() {
		return good;
	}

	public void setGood(Boolean good) {
		this.good = good;
	}

	public String getSkill() {
		return skill;
	}

	public void setSkill(String skill) {
		this.skill = skill;
	}

	public Long getFirstMovieId() {
		return firstMovieId;
	}

	public void setFirstMovieId(Long firstMovieId) {
		this.firstMovieId = firstMovieId;
	}

	public World getHomeWorld() {
		return homeWorld;
	}

	public void setHomeWorld(World homeWorld) {
		this.homeWorld = homeWorld;
	}

}
