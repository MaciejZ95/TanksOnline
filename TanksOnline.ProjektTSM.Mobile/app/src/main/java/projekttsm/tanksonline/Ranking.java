package projekttsm.tanksonline;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.google.gson.Gson;

import org.json.JSONObject;

public class Ranking extends AppCompatActivity {


    JsonObjectRequest jsObjRequest = new JsonObjectRequest
            (Request.Method.GET, R.string.apiUrl + "api/Users", null, new Response.Listener<JSONObject>() {

                @Override
                public void onResponse(JSONObject response) {
                    Log.e("ERROR", "Response " + response.toString());

                    Gson gson = new Gson();

                    ((TextView)findViewById(R.id.helloWorld)).setText("Response " + response.toString());
                }
            }, new Response.ErrorListener() {

                @Override
                public void onErrorResponse(VolleyError error) {
                    Log.e("ERROR", "KURWA ERROR", error);
                }
            });

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ranking);


    }
}
