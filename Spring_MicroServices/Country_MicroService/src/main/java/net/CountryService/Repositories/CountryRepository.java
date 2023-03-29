package net.CountryService.Repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import net.CountryService.Beans.Country;

@Repository
public interface CountryRepository extends JpaRepository<Country, Integer> {

}
