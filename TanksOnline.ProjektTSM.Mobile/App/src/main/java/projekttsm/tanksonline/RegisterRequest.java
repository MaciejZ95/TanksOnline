package projekttsm.tanksonline;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import  java.util.HashMap;
import  java.util.Map;
/**
 * Created by Gabriel on 24.05.2017.
 */

public class RegisterRequest extends StringRequest {
    private static final String url = "http://localhost:21021/api/Register";
    private Map<String, String> params;

    public RegisterRequest(String email, String name, String pass, Response.Listener<String> listener){
        super(Request.Method.POST, url, listener, null);
        params = new HashMap<>();
        params.put("name", name);
        params.put("email", email);
        params.put("password", pass);
    }
    @Override
    public  Map<String, String>getParams(){
        return  params;
    }
}
