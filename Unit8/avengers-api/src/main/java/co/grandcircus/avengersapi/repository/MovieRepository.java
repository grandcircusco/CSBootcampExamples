package co.grandcircus.avengersapi.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import co.grandcircus.avengersapi.model.Movie;

public interface MovieRepository extends JpaRepository<Movie, Long> {
	List<Movie> findByTitle(String title);
	List<Movie> findByReleaseYear(Integer year);
}
