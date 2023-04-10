package net.CountryMicroService;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestMethodOrder;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.junit.jupiter.api.MethodOrderer.OrderAnnotation;
import org.junit.jupiter.api.Order;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.http.MediaType;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;

import com.fasterxml.jackson.databind.ObjectMapper;

import net.CountryService.Beans.Country;
import net.CountryService.Controllers.CountryController;
import net.CountryService.Services.CountryService;

@TestMethodOrder(OrderAnnotation.class)
@ComponentScan(basePackages = "com.restservices.CountryService")
@AutoConfigureMockMvc
@ContextConfiguration
@SpringBootTest(classes = { ControllerMockMVCTests.class })
class ControllerMockMVCTests {

	@Autowired
	MockMvc Mockmvc;
	
	@Mock
	CountryService countryService;
	
	@InjectMocks
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
	
	@BeforeEach
	void setUp() {
		Mockmvc = MockMvcBuilders.standaloneSetup(countryController).build();
	}
	
	@Test
	@Order(1)
	void test_getAllCountries() throws Exception {
		when(countryService.getAllCountries()).thenReturn(myCountries);
		
		this.Mockmvc.perform(get("/getCountries"))
		.andExpect(status().isFound())
		.andDo(print());
	}
	
	@Test
	@Order(2)
	void test_getCountryByID() throws Exception {
		country = new Country(2, "USA", "Washington");
		int countryID = 2;
		
		when(countryService.getCountryById(countryID)).thenReturn(country);
		
		this.Mockmvc.perform(get("/getCountries/{id}", countryID))
		.andExpect(status().isFound())
		.andExpect(MockMvcResultMatchers.jsonPath(".id").value(2))
		.andExpect(MockMvcResultMatchers.jsonPath(".countryName").value("USA"))
		.andExpect(MockMvcResultMatchers.jsonPath(".countryCapital").value("Washington"))
		.andDo(print());
	}
	
	@Test
	@Order(3)
	void test_getCountryByName() throws Exception {
		country = new Country(3, "Canada", "Montreal");
		String countryName = "Canada";
		
		when(countryService.getCountryByName(countryName)).thenReturn(country);
		
		this.Mockmvc.perform(get("/getCountries/countryName").param("name", "Canada"))
		.andExpect(status().isFound())
		.andExpect(MockMvcResultMatchers.jsonPath(".id").value(3))
		.andExpect(MockMvcResultMatchers.jsonPath(".countryName").value("Canada"))
		.andExpect(MockMvcResultMatchers.jsonPath(".countryCapital").value("Montreal"))
		.andDo(print());
	}
	
	@Test
	@Order(4)
	void test_addCountry() throws Exception {
		country = new Country(4, "Japan", "Tokyo");
		String countryName = "Canada";
		
		when(countryService.addCountry(country)).thenReturn(country);
		
		ObjectMapper mapper = new ObjectMapper();
		String jsonBody = mapper.writeValueAsString(country);
		
		this.Mockmvc.perform(post("/addCountry")
				.content(jsonBody)
				.contentType(MediaType.APPLICATION_JSON)
				)
		.andExpect(status().isCreated())
		.andDo(print());
	}
	
	@Test
	@Order(5)
	void test_updateCountry() throws Exception {
		country = new Country(5, "Brasil", "Rio De Janerio");
		int countryID = 5;
		country.setCountryName("Brazil");
		country.setCountryCapital("Brasília");
		when(countryService.getCountryById(countryID)).thenReturn(country);
		when(countryService.updateCountry(country)).thenReturn(country);
		
		ObjectMapper mapper = new ObjectMapper();
		String jsonBody = mapper.writeValueAsString(country);
		this.Mockmvc.perform(put("/updateCountry/{id}", countryID)
				.content(jsonBody)
				.contentType(MediaType.APPLICATION_JSON)
				)
		.andExpect(status().isOk())
		.andExpect(MockMvcResultMatchers.jsonPath(".countryName").value("Brazil"))
		.andExpect(MockMvcResultMatchers.jsonPath(".countryCapital").value("Brasília"))
		.andDo(print());
	}
	
	@Test
	@Order(6)
	void test_deleteCountry() throws Exception {
		country = new Country(5, "Brazil", "Brasília");
		int countryID = 5;
		
		when(countryService.getCountryById(countryID)).thenReturn(country);
		
		this.Mockmvc.perform(delete("/deleteCountry/{id}", countryID))
		.andExpect(status().isOk());
	}
}
