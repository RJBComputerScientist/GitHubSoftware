package net.CountryService.Services;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import net.CountryService.Beans.Country;

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
	
	public Country getCountryById(String countryName) {
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

}
