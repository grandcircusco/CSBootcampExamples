package co.grandcircus.avengersapi.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Sort;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;

import co.grandcircus.avengersapi.model.Movie;
import co.grandcircus.avengersapi.repository.MovieRepository;

@RestController
@RequestMapping("/movies")
public class MovieController {
	@Autowired
	private MovieRepository movieRepo;

	// C(R)UD -- Read All
	@GetMapping
	public List<Movie> readAll(@RequestParam(required = false) String title,
			@RequestParam(required = false) Integer releaseYear, @RequestParam(required = false) String sort) {
		if (title != null && !title.isBlank()) {
			return movieRepo.findByTitle(title);
		} else if (releaseYear != null) {
			return movieRepo.findByReleaseYear(releaseYear);
		} else if ("title".equals(sort) || "releaseYear".equals(sort)) {
			// If the sort option is valid, use that.
			return movieRepo.findAll(Sort.by(sort));
		} else {
			// Default list all and sort by year.
			return movieRepo.findAll(Sort.by("releaseYear"));
		}
	}

	// C(R)UD -- Read One
	@GetMapping("/{id}")
	public Movie readOne(@PathVariable("id") Long id) {
		return movieRepo.findById(id)
				.orElseThrow(() -> new MovieNotFoundException(id));
	}

	// (C)RUD -- Create
	@PostMapping
	@ResponseStatus(HttpStatus.CREATED)
	public Movie create(@RequestBody Movie movie) {
		movie.setId(null); // just to be safe... new entries should not have ID already set
		movieRepo.save(movie);
		return movie;
	}

	// CRU(D) -- Delete
	@DeleteMapping("/{id}")
	@ResponseStatus(HttpStatus.NO_CONTENT)
	public void delete(@PathVariable("id") Long id) {
		movieRepo.deleteById(id);
	}

	// CR(U)D -- Update
	@PutMapping("/{id}")
	public Movie update(@PathVariable("id") Long id, @RequestBody Movie movie) {
		movie.setId(id);
		return movieRepo.save(movie);
	}

	@ResponseBody
	@ExceptionHandler(MovieNotFoundException.class)
	@ResponseStatus(HttpStatus.NOT_FOUND)
	String movieNotFoundHandler(MovieNotFoundException ex) {
		return ex.getMessage();
	}
}
