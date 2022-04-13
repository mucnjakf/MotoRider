package motorider.rpc;

import java.io.IOException;
import org.apache.xmlrpc.XmlRpcException;
import org.apache.xmlrpc.server.PropertyHandlerMapping;
import org.apache.xmlrpc.webserver.WebServer;

public class MotoRiderRPC {

    public static void main(String[] args) throws XmlRpcException, IOException {
        System.err.println("Starting XML-RPC server...");
        WebServer server = new WebServer(8080);

        PropertyHandlerMapping handlerMapping = new PropertyHandlerMapping();
        handlerMapping.addHandler("DhmzService", DhmzService.class);
        server.getXmlRpcServer().setHandlerMapping(handlerMapping);

        server.start();
        System.err.println("XML-RPC server started.");
        System.err.println("Waiting for requests...");
    }
}
