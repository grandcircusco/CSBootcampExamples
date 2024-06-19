package co.grandcircus.avengersapi.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
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

import co.grandcircus.avengersapi.model.World;
import co.grandcircus.avengersapi.repository.WorldRepository;

@RestController
@RequestMapping("worlds")
public class WorldController {
	@Autowired
	private WorldRepository worldRepo;
	
	// C(R)UD -- Read All
	@GetMapping("")
	public List<World> readAll(@RequestParam(required=false) String skill) {
		if (skill != null) {
			return worldRepo.findAll();
		} else {
			return worldRepo.findAll();
		}
	}
	
	// C(R)UD -- Read One
	@GetMapping("{id}")
	public World readOne(@PathVariable("id") Long id) {
		return worldRepo.findById(id).orElseThrow(() -> new WorldNotFoundException(id) );
	}
	
	// (C)RUD -- Create
	@PostMapping("")
	@ResponseStatus(HttpStatus.CREATED)
	public World create(@RequestBody World world) {
		world.setId(null); // just to be safe... new entries should not have ID already set
		worldRepo.save(world);
		return world;
	}
	
	// CRU(D) -- Delete
	@DeleteMapping("{id}")
	@ResponseStatus(HttpStatus.NO_CONTENT)
	public void delete(@PathVariable("id") Long id) {
		worldRepo.deleteById(id);
	}
	
	// CR(U)D -- Update
	@PutMapping("{id}")
	public World update(@PathVariable("id") Long id,
			@RequestBody World world) {
		world.setId(id);
		return worldRepo.save(world);
	}
	
	@ResponseBody
	@ExceptionHandler(WorldNotFoundException.class)
	@ResponseStatus(HttpStatus.NOT_FOUND)
	String worldNotFoundHandler(WorldNotFoundException ex) {
		return ex.getMessage();
	}	
}
