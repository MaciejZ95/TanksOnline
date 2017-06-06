package projekttsm.tanksonline;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.ListView;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.google.gson.Gson;

import org.json.JSONArray;
import org.json.JSONObject;

import projekttsm.tanksonline.Models.UserModel;

public class Ranking extends AppCompatActivity {
    private UserModel[] data = null;

    JsonArrayRequest jsObjRequest;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ranking);

        jsObjRequest = new JsonArrayRequest(
                Request.Method.GET,
                Ranking.this.getString(R.string.apiiUrl) + "api/Users/GetTop10Ranking",
                null, new Response.Listener<JSONArray>() {

                    @Override
                    public void onResponse(JSONArray response) {
                        if (response != null) {
                            Gson gson = new Gson();
                            Log.e("RAFAL", response.toString());
                            data = gson.fromJson(response.toString(), UserModel[].class);

                            RankingListAdapter adapter = new RankingListAdapter(Ranking.this, data);
                            ((ListView) Ranking.this.findViewById(R.id.list)).setAdapter(adapter);
                        }
                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        Log.e("ERROR", "RAFAL ERROR", error);
                    }
                });

        MySingleton.getInstance(this).addToRequestQueue(jsObjRequest);
    }
}
