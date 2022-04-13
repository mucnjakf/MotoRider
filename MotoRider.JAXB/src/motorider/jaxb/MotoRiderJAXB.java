package motorider.jaxb;

import java.io.File;
import java.math.BigInteger;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;
import org.datacontract.schemas._2004._07.motorider_shared.Motorcycle;
import org.datacontract.schemas._2004._07.motorider_shared.ObjectFactory;

public class MotoRiderJAXB {

    public static void main(String[] args) throws JAXBException {
        ObjectFactory factory = new ObjectFactory();
        Motorcycle newMotorcycle = factory.createMotorcycle();
        newMotorcycle.setMake("Aprilia");
        newMotorcycle.setModel("R4");
        newMotorcycle.setYearOfManufacture(new BigInteger("2010"));
        newMotorcycle.setMileage(BigInteger.valueOf(123));
        newMotorcycle.setPrice(1234.56);
        newMotorcycle.setAvailableForRent(true);

        JAXBContext jaxb = JAXBContext.newInstance(Motorcycle.class);
        
        Marshaller marshaller = jaxb.createMarshaller();
        marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
        marshaller.marshal(newMotorcycle, new File("motorcycle.xml"));

        Unmarshaller unmarshaller = jaxb.createUnmarshaller();
        Motorcycle oldMotorcycle = (Motorcycle) unmarshaller.unmarshal(new File("motorcycle.xml"));
        System.out.println(oldMotorcycle.getMake());
        System.out.println(oldMotorcycle.getModel());
        System.out.println(oldMotorcycle.getYearOfManufacture());
        System.out.println(oldMotorcycle.getMileage());
        System.out.println(oldMotorcycle.getPrice());
        System.out.println(oldMotorcycle.isAvailableForRent());
    }
}
