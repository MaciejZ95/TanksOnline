package projekttsm.tanksonline;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import  java.util.HashMap;
import  java.util.Map;
/**
 * Created by Gabriel on 24.05.2017.
 */

public class LoginRequest extends StringRequest {
    private static final String url = "http://150.254.146.142:3000/api/Login";
    private Map<String, String> params;

    public LoginRequest(String email, String pass, Response.Listener<String> listener){
        super(Request.Method.POST, url, listener, null);
        params = new HashMap<>();
        params.put("email", email);
        params.put("password", pass);
    }
    @Override
    public  Map<String, String>getParams(){
        return  params;
    }
}
