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
	String countryName;
	@Column(name="capital")
	String countryCapital;
	public Country() {
		
	}
	public Country(int id, String countryName, String countryCapital) {
		super();
		this.id = id;
		this.countryName = countryName;
		this.countryCapital = countryCapital;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getCountryName() {
		return countryName;
	}
	public void setCountryName(String name) {
		this.countryName = name;
	}
	public String getCountryCapital() {
		return countryCapital;
	}
	public void setCountryCapital(String countryCapital) {
		this.countryCapital = countryCapital;
	}
	
}
