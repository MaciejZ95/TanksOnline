package projekttsm.tanksonline;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.ListView;
import android.widget.Toast;
import android.widget.Button;
import android.widget.EditText;
import android.content.Intent;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.google.gson.Gson;

import org.json.JSONArray;

import projekttsm.tanksonline.Models.UserModel;


public class LoginActivity extends AppCompatActivity {

    Button b1, b2;
    EditText ed1, ed2;
    private UserModel[] data = null;
    JsonArrayRequest jsObjRequest;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.content_login);

        b1 = (Button) findViewById(R.id.LoginButton);
        b2 = (Button) findViewById(R.id.registerButton);
        ed1 = (EditText) findViewById(R.id.nameText);
        ed2 = (EditText) findViewById(R.id.passwordText);


        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                jsObjRequest = new JsonArrayRequest(
                        Request.Method.GET,
                        LoginActivity.this.getString(R.string.apiiUrl) + "api/Users/",
                        null, new Response.Listener<JSONArray>() {

                    @Override
                    public void onResponse(JSONArray response) {
                        if (response != null) {
                            Gson gson = new Gson();
                            Log.e("RAFAL", response.toString());
                            data = gson.fromJson(response.toString(), UserModel[].class);

                            RankingListAdapter adapter = new RankingListAdapter(LoginActivity.this, data);
                            ((ListView) LoginActivity.this.findViewById(R.id.list)).setAdapter(adapter);
                        }
                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        Log.e("ERROR", "RAFAL ERROR", error);
                    }
                });

                Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                startActivity(intent);
            }
        });



        b2.setOnClickListener(new View.OnClickListener(){
            @Override
                    public  void  onClick(View v) {
                Intent intent = new Intent(LoginActivity.this, RegisterActivity.class);
                startActivity(intent);
            }
        });
    }
}



