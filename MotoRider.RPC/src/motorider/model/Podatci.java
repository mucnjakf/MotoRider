package motorider.model;

import javax.xml.bind.annotation.XmlElement;

public class Podatci {
    
    @XmlElement(name = "Temp")
    private String Temp;
    
    @XmlElement(name = "Vlaga")
    private String Vlaga;
    
    @XmlElement(name = "Tlak")
    private String Tlak;
    
    @XmlElement(name = "TlakTrend")
    private String TlakTend;
    
    @XmlElement(name = "VjetarSmjer")
    private String VjetarSmjer;
    
    @XmlElement(name = "VjetarBrzina")
    private String VjetarBrzina;
    
    @XmlElement(name = "Vrijeme")
    private String Vrijeme;
    
    @XmlElement(name = "VrijemeZnak")
    private String VrijemeZnak;

    public Podatci() {
    }

    public Podatci(String Temp, String Vlaga, String Tlak, String TlakTend, String VjetarSmjer, String VjetarBrzina, String Vrijeme, String VrijemeZnak) {
        this.Temp = Temp;
        this.Vlaga = Vlaga;
        this.Tlak = Tlak;
        this.TlakTend = TlakTend;
        this.VjetarSmjer = VjetarSmjer;
        this.VjetarBrzina = VjetarBrzina;
        this.Vrijeme = Vrijeme;
        this.VrijemeZnak = VrijemeZnak;
    }

    public String getTemp() {
        return Temp;
    }

    public void setTemp(String Temp) {
        this.Temp = Temp;
    }

    public String getVlaga() {
        return Vlaga;
    }

    public void setVlaga(String Vlaga) {
        this.Vlaga = Vlaga;
    }

    public String getTlak() {
        return Tlak;
    }

    public void setTlak(String Tlak) {
        this.Tlak = Tlak;
    }

    public String getTlakTend() {
        return TlakTend;
    }

    public void setTlakTend(String TlakTend) {
        this.TlakTend = TlakTend;
    }

    public String getVjetarSmjer() {
        return VjetarSmjer;
    }

    public void setVjetarSmjer(String VjetarSmjer) {
        this.VjetarSmjer = VjetarSmjer;
    }

    public String getVjetarBrzina() {
        return VjetarBrzina;
    }

    public void setVjetarBrzina(String VjetarBrzina) {
        this.VjetarBrzina = VjetarBrzina;
    }

    public String getVrijeme() {
        return Vrijeme;
    }

    public void setVrijeme(String Vrijeme) {
        this.Vrijeme = Vrijeme;
    }

    public String getVrijemeZnak() {
        return VrijemeZnak;
    }

    public void setVrijemeZnak(String VrijemeZnak) {
        this.VrijemeZnak = VrijemeZnak;
    }
}
