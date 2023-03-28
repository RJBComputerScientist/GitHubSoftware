package net.CountryService.Controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
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
	static CountryService countryservice;
	
	@GetMapping("/getCountries")
	public List getCountries() {
		return countryservice.getAllCountries();
	}
	
	@GetMapping("/getCountries/{id}") //for path variables
	public Country getCountryById(@PathVariable(value="id") int id) {
		return countryservice.getCountryById(id);
	}
	
	@GetMapping("/getCountries/countryName")
	public Country getCountryByName(@RequestParam(value="name") String name) {
		return countryservice.getCountryByName(name);
	}
	
	@PostMapping("/addCountry")
	public Country addCountry(@RequestBody Country country) {
		return countryservice.addCountry(country);
	}
	
	@PutMapping("/updateCountry")
	public Country updateCountry(@RequestBody Country country) {
		return countryservice.updateCountry(country);
	}
	
	@DeleteMapping("/deleteCountry/{id}")
	public AddResponse updateCountry(@PathVariable(value="id") int id) {
		return countryservice.deleteCountry(id);
	}
}
