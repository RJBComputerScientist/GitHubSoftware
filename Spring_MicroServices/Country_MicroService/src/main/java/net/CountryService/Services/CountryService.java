package net.CountryService.Services;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import net.CountryService.Beans.Country;
import net.CountryService.Controllers.AddResponse;
import net.CountryService.Repositories.CountryRepository;

@Service
public class CountryService {
	
	@Autowired
	CountryRepository countryRepo;
	
//	No-Arg Constructor
	public CountryService() {
		
	}
	
	public List getAllCountries() {
		return countryRepo.findAll();
	}
	
	public Country getCountryById(int id) {
		
		List<Country> countries = getAllCountries();
		Country country = null;
		
		for(Country con : countries) {
			if(con.getId() == id) {
				country = con;
			}
		}
		return country;
	}
	
	public Country getCountryByName(String countryName) {
		List<Country> countries = getAllCountries();
		Country country = null;
		for(Country con: countries) {
			if(con.getName().equalsIgnoreCase(countryName)) {
				country = con;
			}
		}
		return country;
	}
	
	public Country addCountry(Country country) {
		country.setId(getMaxId());
//		return countryRepo.save(country);
		countryRepo.save(country);
		return country;
	}
	
	/**
	 * To find the maximum number of countries than 
	 * plus one the size
	 * @return size plus one
	 */
	 int getMaxId() {
//		int max = 0;
//		for(int id: countryIdMap.keySet()) {
//			if(max<=id) {
//				max = id;
//			}
//		}
//		return max+1;
		 if(countryRepo.findAll().size()==0) {
			 return 1;
		 } else {			 
			 return countryRepo.findAll().size()+1;
		 }
	}
	 
	 public Country updateCountry(Country country) {
		 	countryRepo.save(country);
			return country;
		}
	 
//	 public AddResponse deleteCountry(int id) {
//		 countryRepo.deleteById(id);
//		 AddResponse res = new AddResponse();
//		 res.setMsg("Message Deleted...");
//		 res.setId(id);
//		 return res;
//	 }
	 
	 public void deleteCountry(Country country) {
		 countryRepo.delete(country);
	 }
	 

}
