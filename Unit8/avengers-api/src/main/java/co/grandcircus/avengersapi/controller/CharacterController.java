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

import co.grandcircus.avengersapi.model.AvCharacter;
import co.grandcircus.avengersapi.repository.CharacterRepository;

@RestController
@RequestMapping("characters")
public class CharacterController {
	@Autowired
	private CharacterRepository characterRepo;
	
	// C(R)UD -- Read All
	@GetMapping("")
	public List<AvCharacter> readAll(
			@RequestParam(required = false) String name,
			@RequestParam(required = false) String skill,
			@RequestParam(required = false) Long firstMovieId,
			@RequestParam(required = false) Long homeWorldId,
			@RequestParam(required = false) String homeWorldName) {
		if (name != null && !name.isBlank()) {
			return characterRepo.findByNameContainsIgnoringCase(name);
		} else if (skill != null && !skill.isBlank()) {
			return characterRepo.findBySkill(skill);
		} else if (firstMovieId != null) {
			return characterRepo.findByFirstMovieId(firstMovieId);
		} else if (homeWorldId != null) {
			return characterRepo.findByHomeWorldId(homeWorldId);
		} else if (homeWorldName != null && !homeWorldName.isBlank()) {
			return characterRepo.findByHomeWorldName(homeWorldName);
		} else {
			return characterRepo.findAll();
		}
	}
	
	// C(R)UD -- Read One
	@GetMapping("{id}")
	public AvCharacter readOne(@PathVariable("id") Long id) {
		return characterRepo.findById(id).orElseThrow(() -> new CharacterNotFoundException(id) );
	}
	
	// (C)RUD -- Create
	@PostMapping("")
	@ResponseStatus(HttpStatus.CREATED)
	public AvCharacter create(@RequestBody AvCharacter avchar) {
		avchar.setId(null); // just to be safe... new entries should not have ID already set
		characterRepo.save(avchar);
		return avchar;
	}
	
	// CRU(D) -- Delete
	@DeleteMapping("{id}")
	@ResponseStatus(HttpStatus.NO_CONTENT)
	public void delete(@PathVariable("id") Long id) {
		characterRepo.deleteById(id);
	}
	
	// CR(U)D -- Update
	@PutMapping("{id}")
	public AvCharacter update(@PathVariable("id") Long id,
			@RequestBody AvCharacter avchar) {
		avchar.setId(id);
		return characterRepo.save(avchar);
	}
	
	@ResponseBody
	@ExceptionHandler(CharacterNotFoundException.class)
	@ResponseStatus(HttpStatus.NOT_FOUND)
	String characterNotFoundHandler(CharacterNotFoundException ex) {
		return ex.getMessage();
	}	
}
