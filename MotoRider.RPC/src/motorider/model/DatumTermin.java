package motorider.model;

import javax.xml.bind.annotation.XmlElement;

public class DatumTermin {
    
    @XmlElement(name = "Datum")
    private String Datum;
    
    @XmlElement(name = "Termin")
    private String Termin;

    public DatumTermin() {
    }
        
    public DatumTermin(String Datum, String Termin) {
        this.Datum = Datum;
        this.Termin = Termin;
    }

    public String getDatum() {
        return Datum;
    }

    public void setDatum(String Datum) {
        this.Datum = Datum;
    }
    
    public String getTermin() {
        return Termin;
    }

    public void setTermin(String Termin) {
        this.Termin = Termin;
    }
}
