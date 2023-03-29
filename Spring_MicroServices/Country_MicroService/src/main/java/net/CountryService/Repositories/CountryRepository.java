package net.CountryService.Repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import net.CountryService.Beans.Country;

public interface CountryRepository extends JpaRepository<Country, Integer> {

}
