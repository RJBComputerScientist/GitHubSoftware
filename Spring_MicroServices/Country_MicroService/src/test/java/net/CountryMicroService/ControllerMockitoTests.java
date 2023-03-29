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

}
