package co.grandcircus.avengersapi.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import co.grandcircus.avengersapi.model.World;

public interface WorldRepository extends JpaRepository<World, Long> {

}
