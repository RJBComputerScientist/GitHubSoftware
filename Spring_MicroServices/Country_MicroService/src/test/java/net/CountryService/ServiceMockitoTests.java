package net.CountryService;

import static org.mockito.Mockito.when;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Order;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.springframework.boot.test.context.SpringBootTest;

import net.CountryService.Beans.Country;
import net.CountryService.Repositories.CountryRepository;
import net.CountryService.Services.CountryService;

@SpringBootTest(classes= {ServiceMockitoTests.class})
class ServiceMockitoTests {

	@Mock // allows shorthand mock creation
	CountryRepository countryRepo;
	
	@InjectMocks // Minimizes repetitive mock and spy injection.
	CountryService countryService;
	
	public List<Country> myCountries;
	/**
	 * The Test shouldn't being using the database but 
	 * it should be mocking the data here. 
	 */
	@Test 
	@Order(1) //the order of test executions
	public void test_getAllCountries() {
		
		List<Country> myCountries = new ArrayList<Country>();
		myCountries.add(new Country(1, "USA", "Washington D.C."));
		myCountries.add(new Country(2, "USA", "New York City"));
		when(countryRepo.findAll()).thenReturn(myCountries);
		assertEquals(2, countryService.getAllCountries().size());
	}

}
