package projekttsm.tanksonline;

import android.content.Context;
import android.support.annotation.NonNull;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import projekttsm.tanksonline.Models.UserModel;

/**
 * Created by rafal on 01.06.2017.
 */

public class RankingListAdapter extends ArrayAdapter<UserModel> {

    public RankingListAdapter(@NonNull Context context, UserModel[] data) {
        super(context, 0, data);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        UserModel user = getItem(position);

        if (convertView == null) {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.ranking_list_layout, parent, false);
        }
        // Lookup view for data population
        TextView name = (TextView) convertView.findViewById(R.id.UserName);
        TextView email = (TextView) convertView.findViewById(R.id.UserEmail);
        TextView wongames = (TextView) convertView.findViewById((R.id.WonGames));
        TextView lostgames = (TextView) convertView.findViewById((R.id.LostGames));
        TextView dealedhits = (TextView) convertView.findViewById((R.id.DealedHits));

        // Populate the data into the template view using the data object
        name.setText(user.Name);
        email.setText(user.Email);
        wongames.setText("Zwycięstwa: " + user.UserScore.WonGames);
        lostgames.setText("Przegrane gry: " + user.UserScore.LostGames);
        dealedhits.setText("Zadane obrażenia: " + user.UserScore.DealedHits);

        // Return the completed view to render on screen
        return convertView;
    }
}
