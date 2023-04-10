package net.CountryService.Controllers;

import java.util.List;
import java.util.NoSuchElementException;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import net.CountryService.Beans.Country;
import net.CountryService.Services.CountryService;

@RestController
public class CountryController {

	@Autowired
	CountryService countryservice;
	
	@GetMapping("/getCountries")
	public ResponseEntity<List<Country>> getCountries() {
		try {
			List<Country> countries = countryservice.getAllCountries();
			return new ResponseEntity<List<Country>>(countries, HttpStatus.FOUND);	
		} catch(Exception e) {
			return new ResponseEntity<>(HttpStatus.NOT_FOUND);
		}
	}
	
	@GetMapping("/getCountries/{id}") //for path variables
	public ResponseEntity<Country> getCountryById(@PathVariable(value="id") int id) {
		try {
			Country country = countryservice.getCountryById(id);
			return new ResponseEntity<Country>(country, HttpStatus.FOUND);	
		} catch(Exception e) {
			return new ResponseEntity<>(HttpStatus.NOT_FOUND);
		}
		
	}
	
	@GetMapping("/getCountries/countryName")
	public ResponseEntity<Country> getCountryByName(@RequestParam(value="name") String name) {
		try {
			Country country = countryservice.getCountryByName(name);
			return new ResponseEntity<Country>(country, HttpStatus.FOUND);	
		} catch(NoSuchElementException e) {
			return new ResponseEntity<>(HttpStatus.NOT_FOUND);
		}
	}
	
	@PostMapping("/addCountry")
	public ResponseEntity<Country> addCountry(@RequestBody Country country) {
		try {
			country = countryservice.addCountry(country);
			return new ResponseEntity<Country>(country, HttpStatus.CREATED);	
		} catch(NoSuchElementException e) {
			return new ResponseEntity<>(HttpStatus.CONFLICT);
		}
	}
	
	@PutMapping("/updateCountry/{id}")
	public ResponseEntity<Country> updateCountry(@PathVariable(value="id") int id, @RequestBody Country country) {
		try {
			Country existingCountry = countryservice.getCountryById(id);
			existingCountry.setCountryCapital(country.getCountryCapital());
			existingCountry.setCountryName(country.getCountryName());
			Country updated_Country = countryservice.updateCountry(existingCountry);
			return new ResponseEntity<Country>(updated_Country, HttpStatus.OK);	
		} catch(Exception e) {
			return new ResponseEntity<>(HttpStatus.CONFLICT);
		}
	}
	
	@DeleteMapping("/deleteCountry/{id}")
	public ResponseEntity<Country> deleteCountry(@PathVariable(value="id") int id) {
		Country country = null;
		try {
			country = countryservice.getCountryById(id);
			countryservice.deleteCountry(country);
		} catch (NoSuchElementException e) {
			return new ResponseEntity<>(HttpStatus.NOT_FOUND);
		}
		return new ResponseEntity<Country>(country, HttpStatus.OK);	
	}
}
