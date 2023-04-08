package net.CountryMicroService;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.when;

import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestMethodOrder;
import org.junit.jupiter.api.MethodOrderer.OrderAnnotation;
import org.junit.jupiter.api.Order;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

import net.CountryService.Beans.Country;
import net.CountryService.Controllers.CountryController;
import net.CountryService.Services.CountryService;

@TestMethodOrder(OrderAnnotation.class)
@SpringBootTest(classes= {ServiceMockitoTests.class})
class ControllerMockitoTests {
	
	@Mock // allows shorthand mock creation
	CountryService countryService;
	
	@InjectMocks // Minimizes repetitive mock and spy injection.
	CountryController countryController;
	
	static List<Country> myCountries;
	static Country country;
	
	@BeforeAll
	static void placeCountries() {
		myCountries = new ArrayList<Country>();
		myCountries.add(new Country(1, "Jamaica", "Kingston"));
		myCountries.add(new Country(2, "USA", "Washington D.C"));
		
		country = new Country(0, "blank", "blank");
	}

	@Test @Order(1)
	public void test_getAllCountries() {
		when(countryService.getAllCountries()).thenReturn(myCountries);
		ResponseEntity<List<Country>> res = countryController.getCountries();
		
		assertEquals(HttpStatus.FOUND, res.getStatusCode());
		assertEquals(2, res.getBody().size());
	}
	
	@Test @Order(2)
	public void test_getCountryByID() {
		country = new Country(2, "Canada", "Montreal");
		int CountryID = 2;
		when(countryService.getCountryById(CountryID)).thenReturn(country);
		ResponseEntity<Country> res = countryController.getCountryById(CountryID);
		
		assertEquals(HttpStatus.FOUND, res.getStatusCode());
		assertEquals(CountryID, res.getBody().getId());
	}
	
	@Test @Order(3)
	public void test_getCountryByName() {
		country = new Country(2, "Canada", "Montreal");
		String CountryName = "Canada";
		when(countryService.getCountryByName(CountryName)).thenReturn(country);
		ResponseEntity<Country> res = countryController.getCountryByName(CountryName);
		
		assertEquals(HttpStatus.FOUND, res.getStatusCode());
		assertEquals(CountryName, res.getBody().getCountryName());
	}
	
	@Test @Order(4)
	public void test_addCountry() {
		country = new Country(3, "USA", "Washington D.C.");
	
		when(countryService.addCountry(country)).thenReturn(country);
		ResponseEntity<Country> res = countryController.addCountry(country);
		
		assertEquals(HttpStatus.CREATED, res.getStatusCode());
		assertEquals(country, res.getBody());
	}
	
	@Test @Order(5)
	public void test_updateCountry() {
		country = new Country(3, "Japan", "Tokyo");
		int CountryID = 3;
		when(countryService.getCountryById(CountryID)).thenReturn(country);
		when(countryService.updateCountry(country)).thenReturn(country);
		ResponseEntity<Country> res = countryController.updateCountry(CountryID, country);
		
		assertEquals(HttpStatus.OK, res.getStatusCode());
		assertEquals(CountryID, res.getBody().getId());
		assertEquals("Japan", res.getBody().getCountryName());
		assertEquals("Tokyo", res.getBody().getCountryCapital());
	}
	
	@Test @Order(6)
	public void test_deleteCountry() {
		country = new Country(3, "Japan", "Tokyo");
		int CountryID = 3;
		when(countryService.getCountryById(CountryID)).thenReturn(country);
		ResponseEntity<Country> res = countryController.deleteCountry(CountryID);
		
		assertEquals(HttpStatus.OK, res.getStatusCode());

	}

}
