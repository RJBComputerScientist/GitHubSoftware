package net.CountryMicroService;

import static org.junit.jupiter.api.Assertions.*;

import org.json.JSONException;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestMethodOrder;
import org.junit.jupiter.api.MethodOrderer.OrderAnnotation;
import org.skyscreamer.jsonassert.JSONAssert;
import org.junit.jupiter.api.Order;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.web.client.TestRestTemplate;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;

import net.CountryService.Beans.Country;


@TestMethodOrder(OrderAnnotation.class)
@SpringBootTest(classes = {ControllerIntegrationTests.class})
class ControllerIntegrationTests {

	@Test
	@Order(1)
	void test_getAllCountriesIntegration() throws JSONException {
		String Expected = "[\r\n"
				+ "		{\r\n"
				+ "			\"id\": 1,\r\n"
				+ " 		\"countryName\": \"Jamaica\",\r\n"
				+ " 		\"countryCapital\": \"Kingston\"\r\n"
				+ "		},\r\n"
				+ "		{\r\n"
				+ "			\"id\": 2,\r\n"
				+ " 		\"countryName\": \"USA\",\r\n"
				+ " 		\"countryCapital\": \"Washington\"\r\n"
				+ "		}\r\n"
				+ "]";
		
		TestRestTemplate restTemp = new TestRestTemplate();
		ResponseEntity<String> response =
		restTemp.getForEntity("http://localhost:8080/getCountries", String.class);
		System.out.println(response.getStatusCode());
		System.out.println(response.getBody());
		
		JSONAssert.assertEquals(Expected, response.getBody(), false);
	}
	
	@Test
	@Order(2)
	void test_getCountryByIdIntegration() throws JSONException {
		
		String Expected = "{\r\n"
				+ "			\"id\": 1,\r\n"
				+ " 		\"countryName\": \"Jamaica\",\r\n"
				+ " 		\"countryCapital\": \"Kingston\"\r\n"
				+ "}";
		
		TestRestTemplate restTemp = new TestRestTemplate();
		ResponseEntity<String> response =
		restTemp.getForEntity("http://localhost:8080/getCountries/1", String.class);
		System.out.println(response.getStatusCode());
		System.out.println(response.getBody());
		
		JSONAssert.assertEquals(Expected, response.getBody(), false);
	}
	
	@Test
	@Order(3)
	void test_getCountryByNameIntegration() throws JSONException {
		
		String Expected = "{\r\n"
				+ "			\"id\": 2,\r\n"
				+ " 		\"countryName\": \"USA\",\r\n"
				+ " 		\"countryCapital\": \"Washington\"\r\n"
				+ "}";
		
		TestRestTemplate restTemp = new TestRestTemplate();
		ResponseEntity<String> response =
		restTemp.getForEntity("http://localhost:8080/getCountries/countryName?name=USA", String.class);
		System.out.println(response.getStatusCode());
		System.out.println(response.getBody());
		
		JSONAssert.assertEquals(Expected, response.getBody(), false);
	}
	
	@Test
	@Order(4)
	void test_addCountryIntegration() throws JSONException {
		Country country = new Country(3, "Japan", "Tokyo");
		String Expected = "{\r\n"
				+ "			\"id\": 3,\r\n"
				+ " 		\"countryName\": \"Japan\",\r\n"
				+ " 		\"countryCapital\": \"Tokyo\"\r\n"
				+ "}";
		
		TestRestTemplate restTemp = new TestRestTemplate();
		HttpHeaders headers = new HttpHeaders();
		headers.setContentType(MediaType.APPLICATION_JSON);
		HttpEntity<Country> request = new HttpEntity<Country>(country, headers);
		ResponseEntity<String> response =
		restTemp.postForEntity("http://localhost:8080/addCountry", request, String.class);
		System.out.println(response.getStatusCode());
		System.out.println(response.getBody());
		assertEquals(HttpStatus.CREATED, response.getStatusCode());
		JSONAssert.assertEquals(Expected, response.getBody(), false);
	}
	
	@Test
	@Order(5)
	void test_updateCountryIntegration() throws JSONException {
		Country country = new Country(3, "Canada", "Montreal");
		String Expected = "{\r\n"
				+ "			\"id\": 3,\r\n"
				+ " 		\"countryName\": \"Canada\",\r\n"
				+ " 		\"countryCapital\": \"Montreal\"\r\n"
				+ "}";
		
		TestRestTemplate restTemp = new TestRestTemplate();
		HttpHeaders headers = new HttpHeaders();
		headers.setContentType(MediaType.APPLICATION_JSON);
		HttpEntity<Country> request = new HttpEntity<Country>(country, headers);
		ResponseEntity<String> response =
		restTemp.exchange("http://localhost:8080/updateCountry/3", HttpMethod.PUT, request, String.class);
		System.out.println(response.getStatusCode());
		System.out.println(response.getBody());
		assertEquals(HttpStatus.OK, response.getStatusCode());
		JSONAssert.assertEquals(Expected, response.getBody(), false);
	}
	
	@Test
	@Order(6)
	void test_deleteCountryIntegration() throws JSONException {
		Country country = new Country(3, "Canada", "Montreal");
		String Expected = "{\r\n"
				+ "			\"id\": 3,\r\n"
				+ " 		\"countryName\": \"Canada\",\r\n"
				+ " 		\"countryCapital\": \"Montreal\"\r\n"
				+ "}";
		
		TestRestTemplate restTemp = new TestRestTemplate();
		HttpHeaders headers = new HttpHeaders();
		headers.setContentType(MediaType.APPLICATION_JSON);
		HttpEntity<Country> request = new HttpEntity<Country>(country, headers);
		ResponseEntity<String> response =
		restTemp.exchange("http://localhost:8080/deleteCountry/3", HttpMethod.DELETE, request, String.class);
		System.out.println(response.getStatusCode());
		System.out.println(response.getBody());
		assertEquals(HttpStatus.OK, response.getStatusCode());
		JSONAssert.assertEquals(Expected, response.getBody(), false);
	}

}
