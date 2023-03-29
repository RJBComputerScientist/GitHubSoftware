package net.CountryService.Beans;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="Country") // name of table should be the same as the class
public class Country {
	@Id
	@Column(name="id")
	int id;
	@Column(name="country_name")
	String name;
	@Column(name="capital")
	String countryCapital;
	public Country() {
		
	}
	public Country(int id, String name, String countryCapital) {
		super();
		this.id = id;
		this.name = name;
		this.countryCapital = countryCapital;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getCountryCapital() {
		return countryCapital;
	}
	public void setCountryCapital(String countryCapital) {
		this.countryCapital = countryCapital;
	}
	
}