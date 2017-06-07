package projekttsm.tanksonline;

import android.app.AlertDialog;
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
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.google.gson.Gson;
import com.google.gson.JsonObject;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

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
                final String emailEd = ed1.getText().toString();
                final String passwordEd = ed2.getText().toString();

                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            String email = jsonResponse.getString("Email");
                            String name = jsonResponse.getString("Name");
                            String pass = jsonResponse.getString("Password");

                            AlertDialog.Builder builder = new AlertDialog.Builder(LoginActivity.this);

                            //if(emailEd == email && passwordEd == pass){
                                                           builder.setMessage("Udało Ci się zalogować!")
                                        .setNegativeButton("Zatwierdz", null)
                                        .show();
                                Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                                intent.putExtra("Email", email);
                                intent.putExtra("Name", name);
                                startActivity(intent);
                            //}
                            //else
                            //{
                                //builder.setMessage("Błędny login lub hasło")
                                 //       .setNegativeButton("Ponów", null)
                                  //      .create()
                                    //    .show();
                            //}

                        }
                        catch (JSONException e){

                        }
                    }
                };
                LoginRequest loginRequest = new LoginRequest(emailEd, passwordEd, responseListener);
                RequestQueue queue = Volley.newRequestQueue(LoginActivity.this);
                queue.add(loginRequest);
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



