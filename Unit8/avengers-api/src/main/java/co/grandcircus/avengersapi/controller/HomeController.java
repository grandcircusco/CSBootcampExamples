package co.grandcircus.avengersapi.controller;

import java.util.LinkedHashMap;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import co.grandcircus.avengersapi.model.AvCharacter;
import co.grandcircus.avengersapi.model.Movie;
import co.grandcircus.avengersapi.model.World;
import co.grandcircus.avengersapi.repository.CharacterRepository;
import co.grandcircus.avengersapi.repository.MovieRepository;
import co.grandcircus.avengersapi.repository.WorldRepository;
import jakarta.annotation.PostConstruct;

@RestController
public class HomeController {
	@Autowired
	private CharacterRepository characterRepo;
	@Autowired
	private MovieRepository movieRepo;
	@Autowired
	private WorldRepository worldRepo;
	
	// Status response for root URL path
	@RequestMapping("/")
	public Map<String, Object> home() {
		Map<String, Object> result = new LinkedHashMap<>();
		result.put("status", "OK");
		result.put("collections", new String[] { "/characters", "/movies", "/worlds" });
		result.put("reset data", "/reset");
		return result;
	}	
	
	@GetMapping("/reset")
	public String reset() {
		
		// Delete all
		characterRepo.deleteAll();
		movieRepo.deleteAll();
		worldRepo.deleteAll();
		
		// Add movies
		Movie ironMan = movieRepo.save(new Movie("Iron Man", 2008));
		Movie thor = movieRepo.save(new Movie("Thor", 2011));
		Movie incredibleHulk = movieRepo.save(new Movie("The Incredible Hulk", 2008));
		Movie civilWar = movieRepo.save(new Movie("Captain America: Civil War", 2016));
		Movie doctorStrange = movieRepo.save(new Movie("Doctor Strange", 2016));
		Movie avengers = movieRepo.save(new Movie("The Avengers", 2012));
		
		// Add worlds
		World earth = worldRepo.save(new World("Earth"));
		World titan = worldRepo.save(new World("Titan"));
		World asgard = worldRepo.save(new World("Asgard"));
		
		// Add characters
		AvCharacter ac = new AvCharacter("Iron Man", 8, true, "flying", ironMan.getId(), earth);
		characterRepo.save(ac);
		
		ac = new AvCharacter("Hulk", 10, true, "strength", incredibleHulk.getId(), earth);
		characterRepo.save(ac);
		
		ac = new AvCharacter("Thor", 9, true, "fighting", thor.getId(), asgard);
		characterRepo.save(ac);
		
		ac = new AvCharacter("Hawkeye", 5, true, "bowmanship", thor.getId(), earth);
		characterRepo.save(ac);
		
		ac = new AvCharacter("Thanos", 9, false, "strength", avengers.getId(), titan);
		characterRepo.save(ac);
		
		ac = new AvCharacter("Black Panther", 8, true, "stealth", civilWar.getId(), earth);
		characterRepo.save(ac);

		ac = new AvCharacter("Dr. Strange", 7, true, "magic", doctorStrange.getId(), earth);
		characterRepo.save(ac);
		
		return "Data reset.";
	}
	
	// @PostConstruct means run this automatically when the application starts.
	@PostConstruct
	public void initializeDatabaseIfEmpty() {
		if (characterRepo.count() == 0) {
			this.reset();
		}
	}
}
