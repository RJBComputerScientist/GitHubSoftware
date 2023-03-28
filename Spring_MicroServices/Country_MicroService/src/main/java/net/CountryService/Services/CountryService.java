package net.CountryService.Services;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.springframework.stereotype.Service;

import net.CountryService.Beans.Country;
import net.CountryService.Controllers.AddResponse;

@Service
public class CountryService {
	
	static HashMap<Integer, Country> countryIdMap;
	
//	No-Arg Constructor
	public CountryService() {
		
	}
	
	public List getAllCountries() {
		return new ArrayList(countryIdMap.values());
	}
	
	public Country getCountryById(int id) {
		return countryIdMap.get(id);
	}
	
	public Country getCountryByName(String countryName) {
		Country country = null;
		for(int a: countryIdMap.keySet()) {
			if(countryIdMap.get(a).getName().equals(countryName)) {
				country = countryIdMap.get(a);
			}
		}
		return country;
	}
	
	public Country addCountry(Country country) {
		country.setId(getMaxId());
		countryIdMap.put(country.getId(), country);
		return country;
	}
	
	 int getMaxId() {
		int max = 0;
		for(int id: countryIdMap.keySet()) {
			if(max<=id) {
				max = id;
			}
		}
		return max+1;
	}
	 
	 public Country updateCountry(Country country) {
			if(country.getId()>0) {
				countryIdMap.put(country.getId(), country);
			}
			return country;
		}
	 
	 public AddResponse deleteCountry(int id) {
		 countryIdMap.remove(id);
		 AddResponse res = new AddResponse();
		 res.setMsg("Message Deleted...");
		 res.setId(id);
		 return res;
	 }
	 

}
