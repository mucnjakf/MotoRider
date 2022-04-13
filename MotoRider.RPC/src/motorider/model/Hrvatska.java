package motorider.model;

import java.util.List;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "Hrvatska")
public class Hrvatska {
    
    @XmlElement(name = "DatumTermin")
    private DatumTermin DatumTermin;    
    
    @XmlElement(name = "Grad")
    private List<Grad> Grad;   

    public Hrvatska() {
    }
    
    public Hrvatska(DatumTermin DatumTermin, List<Grad> Grad) {
        this.DatumTermin = DatumTermin;
        this.Grad = Grad;
    }

    public DatumTermin getDatumTermin() {
        return DatumTermin;
    }

    public void setDatumTermin(DatumTermin DatumTermin) {
        this.DatumTermin = DatumTermin;
    }
    
    public List<Grad> getGrad() {
        return Grad;
    }

    public void setGrad(List<Grad> Grad) {
        this.Grad = Grad;
    }
}
