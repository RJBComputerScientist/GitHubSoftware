package net.CountryMicroService;


import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.MethodOrderer.OrderAnnotation;
import org.junit.jupiter.api.Order;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestMethodOrder;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.springframework.boot.test.context.SpringBootTest;

import net.CountryService.Beans.Country;
import net.CountryService.Repositories.CountryRepository;
import net.CountryService.Services.CountryService;

//The order annotation needs "@TestMethodOrder(OrderAnnotation.class)"
@TestMethodOrder(OrderAnnotation.class)
@SpringBootTest(classes= {ServiceMockitoTests.class})
class ServiceMockitoTests {

	@Mock // allows shorthand mock creation
	CountryRepository countryRepo;
	
	@InjectMocks // Minimizes repetitive mock and spy injection.
	CountryService countryService;
	
	static List<Country> myCountries;
	static Country country;
	
	@BeforeAll
	static void placeCountries() {
		myCountries = new ArrayList<Country>();
		myCountries.add(new Country(1, "Jamaica", "Kingston"));
		myCountries.add(new Country(2, "USA", "Washington D.C"));
		
		country = new Country(0, "blank", "blank");
	}
	/**
	 * The Test shouldn't being using the database but 
	 * it should be mocking the data here. 
	 */
	@Test 
	@Order(1) //the order of test executions
	public void test_getAllCountries() {
		
//		List<Country> myCountries = new ArrayList<Country>();
//		myCountries.add(new Country(1, "USA", "Washington D.C."));
//		myCountries.add(new Country(2, "USA", "New York City"));
		when(countryRepo.findAll()).thenReturn(myCountries);
		assertEquals(2, countryService.getAllCountries().size());
	}
	
	@Test @Order(2) 
	//The order annotation needs "@TestMethodOrder(OrderAnnotation.class)"
	public void test_getCountryById() {
//		List<Country> myCountries = new ArrayList<Country>();
//		myCountries.add(new Country(1, "USA", "Washington D.C."));
//		myCountries.add(new Country(2, "USA", "New York City"));
		int countryID = 1;
		
		when(countryRepo.findAll()).thenReturn(myCountries);
		
		assertEquals(countryID, countryService.getCountryById(countryID).getId());
	}
	
	@Test @Order(3)
	public void test_getCountryByName() {
//		List<Country> myCountries = new ArrayList<Country>();
//		myCountries.add(new Country(1, "USA", "Washington D.C."));
//		myCountries.add(new Country(2, "USA", "New York City"));
		String countryName = "Jamaica";
		
		when(countryRepo.findAll()).thenReturn(myCountries);
		
		assertEquals(countryName, countryService.getCountryByName(countryName).getCountryName());
	}
	
	@Test @Order(4)
	public void test_addCountry() {
//		Country country = new Country(3, "China", "Beijing");
		when(countryRepo.save(country)).thenReturn(country);
		assertEquals(country, countryService.addCountry(country));
		System.out.println(country.getId());
		System.out.println(country.getCountryName());
		System.out.println(country.getCountryCapital());
	}
	
	@Test @Order(5)
	public void test_updateCountry() {
		 country.setCountryName("China");
		 country.setCountryCapital("Beijing");
		when(countryRepo.save(country)).thenReturn(country);
		assertEquals(country, countryService.updateCountry(country));
		System.out.println(country.getId());
		System.out.println(country.getCountryName());
		System.out.println(country.getCountryCapital());
	}
	
	@Test @Order(6)
	public void test_deleteCountry() {
		countryService.deleteCountry(country);
		verify(countryRepo, times(1)).delete(country);
		System.out.println(country.getId());
		System.out.println(country.getCountryName());
		System.out.println(country.getCountryCapital());
	}

}
