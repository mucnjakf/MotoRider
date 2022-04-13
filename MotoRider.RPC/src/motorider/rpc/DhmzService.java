package motorider.rpc;

import java.net.MalformedURLException;
import java.net.URL;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import motorider.model.Grad;
import motorider.model.Hrvatska;

public class DhmzService {

    public String getTemperature(String cityName) throws MalformedURLException, JAXBException {
        URL url = new URL("https://vrijeme.hr/hrvatska_n.xml");

        JAXBContext jaxbContext = JAXBContext.newInstance(Hrvatska.class);

        Unmarshaller jaxbUnmarshaller = jaxbContext.createUnmarshaller();
        Hrvatska hr = (Hrvatska) jaxbUnmarshaller.unmarshal(url);

        for (Grad grad : hr.getGrad()) {
            if (grad.getGradIme().equals(cityName)) {
                return grad.getPodatci().getTemp();
            }
        }

        return "";
    }
}
