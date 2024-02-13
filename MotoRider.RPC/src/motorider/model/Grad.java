package motorider.model;

import javax.xml.bind.annotation.XmlElement;

public class Grad {
    
    @XmlElement(name = "GradIme")
    private String GradIme;
    
    @XmlElement(name = "Lat")
    private String Lat;
    
    @XmlElement(name = "Lon")
    private String Lon;
    
    @XmlElement(name = "Podatci")
    private Podatci Podatci;

    public Grad() {
    }

    public Grad(String GradIme, String Lat, String Lon, Podatci Podatci) {
        this.GradIme = GradIme;
        this.Lat = Lat;
        this.Lon = Lon;
        this.Podatci = Podatci;
    }

    public String getGradIme() {
        return GradIme;
    }

    public void setGradIme(String GradIme) {
        this.GradIme = GradIme;
    }

    public String getLat() {
        return Lat;
    }

    public void setLat(String Lat) {
        this.Lat = Lat;
    }

    public String getLon() {
        return Lon;
    }

    public void setLon(String Lon) {
        this.Lon = Lon;
    }

    public Podatci getPodatci() {
        return Podatci;
    }

    public void setPodatci(Podatci Podatci) {
        this.Podatci = Podatci;
    }
}
