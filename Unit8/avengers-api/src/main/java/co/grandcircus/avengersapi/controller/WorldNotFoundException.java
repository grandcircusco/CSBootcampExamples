package co.grandcircus.avengersapi.controller;

public class WorldNotFoundException extends RuntimeException {

	private static final long serialVersionUID = 1L;

	public WorldNotFoundException(Long id) {
		super("Could not find world with id " + id);
	}
}
